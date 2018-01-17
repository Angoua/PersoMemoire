
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace KpiApp.Models
{
    public class kpi_AchievementType : kpi_Persist
    {
        #region Fields
        private int _iD;
        private string _name; 
        #endregion
        
        #region "Properties"
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        } 
        #endregion       
        
        #region Methods
        public override bool fnGet(object ID)
        {
            try
            {
                db.definirProcedureStockee("kpi_AchievementType_Get");
                db.ajouterParametreEntree("@ID", 32, SqlDbType.Int, (int)ID);

                IDataReader dr = db.executeReader();
                dr.Read();
                mapFromDataReaderToObject(dr, this);
                dr.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override IEnumerable<kpi_Persist> fnSelect()
        {
            return fnSelect(-1);           
        }

        public IEnumerable<kpi_Persist> fnSelect(short status)
        {
            List<kpi_AchievementType> mListe = new List<kpi_AchievementType>();

            db.definirProcedureStockee("kpi_AchievementType_Select");
            db.ajouterParametreEntree("@Status", 8, SqlDbType.SmallInt, status);

            IDataReader reader = db.executeReader();

            while (reader.Read())
            {
                kpi_AchievementType mClass = new kpi_AchievementType();

                mapFromDataReaderToObject(reader, mClass);

                mListe.Add(mClass);
            }
            reader.Close();
            return mListe;
        }

        public override bool fnUpdate()
        {
            bool Result = false;


            if (IsNew)
            {
                db.definirProcedureStockee("kpi_AchievementType_Create");
                db.ajouterParametreSortie("@ID", 32, SqlDbType.Int, _iD);
                db.ajouterParametreSortie("@Rowversion", 50, SqlDbType.Timestamp, RowVersion);
            }
            else
            {
                db.definirProcedureStockee("kpi_AchievementType_Edit");
                db.ajouterParametreEntree("@ID", 32, SqlDbType.Int, _iD);
                db.ajouterParametreEntree("@RowVersion", 50, SqlDbType.Timestamp, RowVersion);
            }
          
            db.ajouterParametreEntree("@Name", 50, SqlDbType.VarChar, _name);
            db.ajouterParametreSortie("@ErrorMessage", 50, SqlDbType.VarChar, "");
           

            db.ajouterParametreRetour("@ReturnValue", 8, SqlDbType.Int);
            IDataReader dr = db.executeReader();
            int RetVal = (int)db.obtenirParametre("@ReturnValue");

            switch (RetVal)
            {
                case 0:
                    RowVersion = (byte[])db.obtenirParametre("@RowVersion");

                    if (IsNew)
                        _iD = (int)db.obtenirParametre("@ID");

                    IsNew = false;
                    Result = true;
                    break;
                default:
                    string errMsg = (string)db.obtenirParametre("@ErrorMessage");
                    Result = false;
                    throw new Exception();
            }
            return Result;

        }

        public override bool fnDelete()
        {
            throw new NotImplementedException();
        }


        public override bool fnActivate()
        {
            bool Result;

            db.definirProcedureStockee("kpi_AchievementType_ActivateDeactivate");
            db.ajouterParametreEntree("@ID", 50, SqlDbType.Int, _iD);
            db.ajouterParametreEntree("@IsDisabled", 50, SqlDbType.Bit, false);
            db.ajouterParametreSortie("@ErrorMessage", 50, SqlDbType.VarChar, "");


            db.ajouterParametreRetour("@ReturnValue", 8, SqlDbType.Int);
            IDataReader dr = db.executeReader();
            int RetVal = (int)db.obtenirParametre("@ReturnValue");

            switch (RetVal)
            {
                case 0:
                    RowVersion = (byte[])db.obtenirParametre("@RowVersion");

                    IsNew = false;
                    Result = true;
                    break;
                default:
                    string errMsg = (string)db.obtenirParametre("@ErrorMessage");
                    Result = false;
                    throw new Exception();
            }
            return Result;
        }


        public override bool fnDeactivate()
        {
            bool Result;

            db.definirProcedureStockee("kpi_AchievementType_ActivateDeactivate");
            db.ajouterParametreEntree("@ID", 50, SqlDbType.Int, _iD);
            db.ajouterParametreEntree("@IsDisabled", 50, SqlDbType.Bit, true);
            db.ajouterParametreSortie("@ErrorMessage", 50, SqlDbType.VarChar, "");


            db.ajouterParametreRetour("@ReturnValue", 8, SqlDbType.Int);
            IDataReader dr = db.executeReader();
            int RetVal = (int)db.obtenirParametre("@ReturnValue");

            switch (RetVal)
            {
                case 0:
                    RowVersion = (byte[])db.obtenirParametre("@RowVersion");                 

                    IsNew = false;
                    Result = true;
                    break;
                default:
                    string errMsg = (string)db.obtenirParametre("@ErrorMessage");
                    Result = false;
                    throw new Exception();
            }
            return Result;
        }

        #endregion

        public kpi_AchievementType()
        {
            db = DataAccessFactory.ObtenirAccesDonnees();
        }
        
        private void mapFromDataReaderToObject(IDataReader reader, kpi_AchievementType achievementType)
        {

            if (reader != null)
            {

                //bool bol = DBNull.Value.Equals(reader["pc_Designation"]);
                //reader.Read();
                if (!Convert.IsDBNull(reader["ID"]))
                    achievementType.ID = (int)reader["ID"];

                if (!Convert.IsDBNull(reader["Name"]))
                    achievementType.Name = reader["Name"].ToString();

                if (!Convert.IsDBNull(reader["IsDisabled"]))
                    achievementType.IsDisabled = (bool)reader["IsDisabled"];

                if (!Convert.IsDBNull(reader["CreationDate"]))
                    achievementType.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());

                if (!Convert.IsDBNull(reader["CreationUser"]))
                    achievementType.CreationUser = reader["CreationUser"].ToString();

                if (!Convert.IsDBNull(reader["ModificationUser"]))
                    achievementType.ModificationUser = reader["ModificationUser"].ToString();


                if (!Convert.IsDBNull(reader["ModificationDate"]))
                    achievementType.ModificationDate = DateTime.Parse(reader["ModificationDate"].ToString());

                if (!Convert.IsDBNull(reader["Rowversion"]))
                    achievementType.RowVersion = (byte[])reader["RowVersion"];

                //reader.Close();
            }
        }

    }
}