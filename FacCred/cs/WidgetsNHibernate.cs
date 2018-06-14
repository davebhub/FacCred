using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Jenzabar.Portal.Framework.NHibernateFWK;
using Jenzabar.Portal.Framework.NHibernateFWK.Base;



namespace FacCred.cs
{
    public class WidgetsNHibernate : JICSBase //added for NHibernate
    {
        public virtual Guid WidgetID { get; set; }
        public virtual Guid PortletID { get; set; }
        public virtual Guid UserID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public WidgetsNHibernate() //Added constructor because nHibernate requires
        {

        }
    }

    public class WidgetsMapperService : JICSBaseFacade<WidgetsNHibernate>
    {

        public IList<WidgetsNHibernate> GetWidgets(Guid portletID, Guid userID)
        {
            return GetQuery().Where(x => x.PortletID == portletID && x.UserID == userID).OrderBy(x => x.Name).ToList();
        }

        public int UpdateWidget(Guid widgetID, string name, string description)
        {

            var list = GetList(x => x.ID == widgetID);

            if (list == null || list.Count == 0)
                return 0;

            list[0].Name = name;
            list[0].Description = description;

            WidgetsMapperService widgetsService = new WidgetsMapperService();

            try
            {
                widgetsService.Save(list[0]);
            }
            catch
            {
                return 0;
            }

            return 1;
        }

        public void RemoveWidgets(Guid portletID)
        {
            IList<WidgetsNHibernate> widgets = GetQuery().Where(x => x.PortletID == portletID).ToList();
            WidgetsMapperService widgetsService = new WidgetsMapperService();
            foreach (WidgetsNHibernate w in widgets)
            {
                widgetsService.Delete(w);
            }
        }
    }
}