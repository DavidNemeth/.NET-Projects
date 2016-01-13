using KisKer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KisKer.ViewModels
{
    public class ErtekesitesViewModel
    {
        public List<Ertekesites> Ertekesitesek { get; set; }
        public ErtekesitesViewModel(KiskerEntities db)
        {
            var qry = from e in db.Ertekesitesek
                      join s in db.ErtekesitesReszletek
                          on e.ErtekesitesID equals s.ErtekesitesID
                      orderby e.ErtekesitesDatum
                      select e;
            Ertekesitesek = qry.ToList();
        }
        public CartViewModel.ErtekesitesReszletekModel ertekesitesTetelek { get; set; }
        public void AddErtekesites(KiskerEntities db, int ErtekesitesID)
        {
            var qry = from s in db.Ertekesitesek
                      join a in db.ErtekesitesReszletek on s.ErtekesitesID equals a.ErtekesitesID
                      where s.ErtekesitesID == ErtekesitesID
                      select s;

            Ertekesitesek = qry.ToList();
        }
        public void AddErtekesitesTetelek(CartViewModel.ErtekesitesReszletekModel dataModell)
        {
            this.ertekesitesTetelek = dataModell;
        }
        public string SaveData(KiskerEntities db)
        {
            List<CartViewModel.ErtekesitesReszletekLine> BevLista = (List<CartViewModel.ErtekesitesReszletekLine>)ertekesitesTetelek.ErtekesitesTetelek;

            BevLista.RemoveAll(p => p.AruMennyiseg == 0);

            if (BevLista.Count() == 0)
            {
                return ("Nincs tétel");
            }
            string errorMsg = null;
            using (var transactions = db.Database.BeginTransaction())
            {
                try
                {
                    Ertekesites tetel = new Ertekesites();
                    tetel.ErtekesitesID = this.Ertekesitesek.FirstOrDefault().ErtekesitesID;                    
                    tetel.ErtekesitesDatum = DateTime.Now;  
                    db.Ertekesitesek.Add(tetel);
                    db.SaveChanges();
                    int ErtekesitesID = tetel.ErtekesitesID;
                    foreach (var tetelIn in BevLista)
                    {
                        ErtekesitesReszlet reszletek = new ErtekesitesReszlet();
                        reszletek.ErtekesitesID = ErtekesitesID;
                        reszletek.AruID = tetelIn.AruID;
                        reszletek.AruKeszlet.EgysegAr = tetelIn.EgysegAr;
                        reszletek.AruMennyiseg = (short)tetelIn.AruMennyiseg;                        
                        db.ErtekesitesReszletek.Add(reszletek);
                        db.SaveChanges();
                    }
                    transactions.Commit();
                }
                catch (Exception ex)
                {
                    transactions.Rollback();
                    errorMsg = ex.Message;
                }
            }
            return (errorMsg);
        }
    }
}