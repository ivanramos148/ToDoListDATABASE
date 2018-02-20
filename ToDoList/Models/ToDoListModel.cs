using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList;
using System;

namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private int _id;

    private static List<Item> _instances = new List<Item> {};

    public Item (string description)
    {
      _description = description;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }

    public int GetId()
    {
      return _id;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM items;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }

    public static List<Item> GetAll()
    {
        List<Item> allItems = new List<Item> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM items;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int itemId = rdr.GetInt32(0);
          string itemDescription = rdr.GetString(1);
          Item newItem = new Item(itemDescription);
          allItems.Add(newItem);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allItems;
    }
    public override bool Equals(System.Object otherItem)
    {
        if (!(otherItem is Item))
        {
          return false;
        }
        else
        {
          Item newItem = (Item) otherItem;
          bool idEquality = (this.GetId() == newItem.GetId());
          bool descriptionEquality = (this.GetDescription() == newItem.GetDescription());
          return (idEquality && descriptionEquality);
        }
    }
    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO items (description) VALUES (@ItemDescription);";

        MySqlParameter description = new MySqlParameter();
        description.ParameterName = "@ItemDescription";
        description.Value = _description;
        cmd.Parameters.Add(description);

        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;  // Notice the slight update to this line of code!

         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
    }

  }
}
