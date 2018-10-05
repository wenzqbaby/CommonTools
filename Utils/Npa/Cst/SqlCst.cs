using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Cst
{
    public class SqlCst
    {
        private SqlCst() { }

        public const String INSERT = "INSERT INTO";
        public const String VALUES = "VALUES";
        public const String UPDATE = "UPDATE";
        public const String SET = "SET";
        public const String AND = "AND ";

        public const String EQUAL = "=";
        public const String NULL = "NULL";
        public const String SEPARATOR = ", ";
        public const String SPACE = " ";
        public const String BRACKET_LEFT = " (";
        public const String BRACKET_RIGHT = ") ";

        public const String INSERT_SQL = @"INSERT INTO {0} ({1}) VALUES ({2})";
        public const String UPDATE_SQL = @"UPDATE {0} SET {1} WHERE {2}";
    }
}
