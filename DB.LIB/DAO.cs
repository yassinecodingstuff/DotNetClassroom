using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DB.LIB
{
    public class DAO : Connexion, IDAO<object>
    {
        public int id = 0;
        protected string sql = "";
        public DAO()
        {
            using (Connexion connexion = new Connexion())
            {
                connexion.Connect();
            }
        }
        public Dictionary<string, object> ObjectToDictionary(object obj)
        {
            var dict = new Dictionary<string, object>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                dict[prop.Name] = prop.GetValue(obj);
            }
            return dict;
        }

        public object DictionaryToObject(Dictionary<string, object> dico)
        {
            object instance = Activator.CreateInstance(this.GetType());

            foreach (var kvp in dico)
            {
                // Gérer les différences de casse et les underscores
                string key = kvp.Key;
                string adjustedKey = key.Replace("_", ""); // Supprime les underscores
                PropertyInfo prop = this.GetType().GetProperty(adjustedKey,
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                if (prop != null && prop.CanWrite)
                {
                    object value = kvp.Value;
                    // Convertir DBNull en null
                    if (value == DBNull.Value)
                    {
                        value = null;
                    }
                    prop.SetValue(instance, value);
                }
            }

            // Assigner l'ID (propriété de la classe de base DAO)
            if (dico.ContainsKey("id"))
            {
                PropertyInfo idProp = typeof(DAO).GetProperty("id");
                if (idProp != null && idProp.CanWrite)
                {
                    idProp.SetValue(instance, Convert.ToInt32(dico["id"]));
                }
            }

            return instance;
        }


        public virtual int insert()
        {
            string tableName = this.GetType().Name;

            // Step 2: Convert the object's properties to a dictionary
            Dictionary<string, object> properties = ObjectToDictionary(this);

            // Step 3: Build the INSERT query dynamically
            var columns = new List<string>();
            var parameters = new List<string>();
            var paramDict = new Dictionary<string, object>();

            foreach (var prop in properties)
            {
                // Skip the "id" column if it’s an auto-incremented primary key
                if (prop.Key.ToLower() == "id") continue;

                columns.Add(prop.Key);
                string paramName = $"@{prop.Key}";
                parameters.Add(paramName);
                paramDict[paramName] = prop.Value ?? DBNull.Value;
            }

            // Build the SQL query
            sql = $"INSERT INTO {tableName} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", parameters)})";

            // Step 4: Execute the query
            return iud(sql, paramDict);
        }

        public virtual int update()
        {
            string tableName = this.GetType().Name;
            Dictionary<string, object> properties = ObjectToDictionary(this);

            var setClauses = new List<string>();
            var paramDict = new Dictionary<string, object>();

            foreach (var prop in properties)
            {
                if (prop.Key.ToLower() == "id" || prop.Key.ToLower() == "code") continue; // Skip the primary key for SET clause
                setClauses.Add($"{prop.Key} = @{prop.Key}");
                paramDict[$"@{prop.Key}"] = prop.Value ?? DBNull.Value;
            }

            // Assume "Code" is the primary key for the WHERE clause
            string primaryKey = properties.ContainsKey("Code") ? "Code" : "id";
            sql = $"UPDATE {tableName} SET {string.Join(", ", setClauses)} WHERE {primaryKey} = @{primaryKey}";
            paramDict[$"@{primaryKey}"] = properties[primaryKey] ?? DBNull.Value;

            return iud(sql, paramDict);
        }

        public virtual int delete()
        {
            throw new NotImplementedException();
        }

        public virtual object findById()
        {
            throw new NotImplementedException();
        }

        public virtual List<object> findAll()
        {
            List<object> results = new List<object>();
            string tableName = this.GetType().Name;
            sql = $"SELECT * FROM {tableName}";

            using (Connexion connexion = new Connexion())
            {
                connexion.Connect();
                using (IDataReader reader = connexion.select(sql, null))
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> dico = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dico[reader.GetName(i)] = reader.GetValue(i);
                        }
                        results.Add(DictionaryToObject(dico));
                    }
                }
            }
            return results;
        }

        public virtual List<object> find()
        {
            throw new NotImplementedException();
        }
    }
}

