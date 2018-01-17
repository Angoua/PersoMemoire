using KpiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Files
{
    public abstract class Persist
    {
        #region Fields
        private IDataAccess _db;
        private bool _isNew = true;
        private bool _statut;
        private string _creationUser;
        private DateTime _creationDate;
        private string _modificationUser;
        private DateTime _modificationDate;
        private byte[] _rowVersion;
        #endregion

        #region Properties
        public IDataAccess db
        {
            get { return _db; }
            set { _db = value; }
        }

        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        public bool Statut
        {
            get { return _statut; }
            set { _statut = value; }
        }

        public string CreationUtilisateur
        {
            get { return _creationUser; }
            set { _creationUser = value; }
        }

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public string ModificationUtilisateur
        {
            get { return _modificationUser; }
            set { _modificationUser = value; }
        }

        public DateTime ModificationDate
        {
            get { return _modificationDate; }
            set { _modificationDate = value; }
        }

        public byte[] RowVersion
        {
            get { return _rowVersion; }
            set { _rowVersion = value; }
        }
        #endregion


        #region Methods
        public abstract bool fnGet(object ID);
        public abstract IEnumerable<Persist> fnSelect();
        public abstract bool fnUpdate();

        //public abstract bool fnActivate();
        //public abstract bool fnDeactivate();

        public abstract bool fnDelete();
        #endregion
    }
}
