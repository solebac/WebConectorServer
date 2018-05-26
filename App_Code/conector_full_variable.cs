using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Implementações lib's
using System.IO;
using System.Net;

    class conector_full_variable
    {
        public conector_full_variable()
        {
        }

        private static string _schema = "";
        public string Schema
        {
            get { return _schema; }
            set { _schema = value; }
        }

        private static string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private static string _senha = "";
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        private static string _Store = "";
        public string Store
        {
            get { return _Store; }
            set { _Store = value; }
        }
        private static string _localHost = "";
        public string LocalHost
        {
            get { return _localHost; }
            set { _localHost = value; }
        }

        private static string _port = "";
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }
    }