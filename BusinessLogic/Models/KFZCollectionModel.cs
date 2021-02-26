using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

using CommonTypes;
using DataAccess;

namespace BusinessLogic.Models
{
    public class KFZCollectionModel
    {
        //Event nach außen publizieren.
        public event KFZDataArrivedEventHandler KFZDataArrived;

        public List<KFZ> KFZListe = new List<KFZ>();        

        
        public KFZCollectionModel()
        {
            //Tür auf! Füs das Event registrieren.
            Connection.KfzListeReady += Connection_KfzListeReady;

            if(Connection.IsConnected)
            {
                GetAllKfz();
            }
            
        }

        private void Connection_KfzListeReady(List<KFZ> kfzs)
        {
            KFZListe = kfzs;

            KFZDataArrived(KFZListe);
        }

        public void GetAllKfz()
        {
            //Alle KFZ aus der Datenquelle abholen und in der Liste speichern:

            //jetzt über Events...
            //this.KFZListe = Connection.GetKfzList();
            Connection.GetKfzList();
        }

        public void Insert(KFZ kfz)
        {
            //Überprüfen, ob das neue Kfz korrekte Werte besitzt.
            if (kfz.Id == -1 &&
                kfz.FahrgestNr != string.Empty &&
                kfz.Kennzeichen != string.Empty &&
                kfz.Leistung > 0
                && kfz.Typ != string.Empty)
            {
                Connection.InsertKFZ(kfz);
            }
        }

        public void Update(KFZ kfz)
        {
            Connection.UpdateKFZ(kfz);
        }

        public void Delete(KFZ kfz)
        {
            //1. KFZ abmelden bei Zulassungsstelle
            //2. Fahrzeughalter benachrichtigen, dass KFZ abgemeldet wurde.
            //3. auf Bestätigung des Halters warten
            //4. usw.
            Connection.DeleteKFZ(kfz);
        }

        #region Private methods

        

        
        #endregion

    }
}
