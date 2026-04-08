using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aacademy
{
	internal class Query
	{
		public string Fields { get; set; }
		public string Tables { get; set; }
		public string Condition { get; set; }
		public Query(string fields, string tables, string conditions = "") 
		{ 
		    Fields = fields;
			Tables = tables;
			Condition = conditions;
		}
		public override string ToString()
		{
			string query = $"SELECT {Fields} FROM {Tables}";
			if (Condition != "") query += $" WHERE {Condition}";
			return query;
		}
	}
}
