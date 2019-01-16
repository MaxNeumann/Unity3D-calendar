using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class db : MonoBehaviour {

	// Use this for initialization
	void Start () {
       string conn = @"URI=file:" + Application.dataPath + @"/Plugins/Calendar.s3db"; //Path to database.
       IDbConnection dbconn;
       dbconn = (IDbConnection)new SqliteConnection(conn);
       dbconn.Open();
       IDbCommand dbcmd = dbconn.CreateCommand();
       string sqlQuery = "SELECT * " + "FROM Usersinfo";
        dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int age = reader.GetInt32(2);

                 Debug.Log("value= " + id + "  Name =" + name + "  Age =" + age);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }

	// Update is called once per frame
	void Update () {
		
	}
}
