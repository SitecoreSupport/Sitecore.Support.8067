namespace Sitecore.Support.XA.Feature.Search.Repositories
{
  using System.Web.Script.Serialization;
  using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
  using System.Linq;
  using Sitecore.Data.Items;
  using Sitecore.Data.Managers;
  using Sitecore.XA.Foundation.IoC;
  using Sitecore.XA.Foundation.Multisite;
  using Templates = Sitecore.XA.Feature.Maps.Templates;

  public class LocationFilterRepository : Sitecore.XA.Feature.Search.Repositories.LocationFilterRepository
  {
    protected override string JsonDataProperties
    {
      get
      {
        var type = new
        {
          endpoint = this.HomeUrl + "/sxa/search/results/",
          f = this.FacetItemName,
          p = this.Rendering.Parameters.ParseInt("MaxPredictiveResultsCount", 0),
          myLocationText = this.MyLocationText,
          mode = this.LocationFilterMode.ToString(),
          searchResultsSignature = this.Rendering.Parameters["SearchSignature"],
          #region Added code
          key = this.GetMapsProviderKey(PageContext.Current) 
          #endregion
        };
        return new JavaScriptSerializer().Serialize(type);
      }
    }

    #region Added code
    private string GetMapsProviderKey(Item contextItem)
    {
      if (ServiceLocator.Current.Resolve<IMultisiteContext>().GetSiteItem(contextItem) != null)
      {
        Item item = ServiceLocator.Current.Resolve<IMultisiteContext>().GetSettingsItem(contextItem).Children.FirstOrDefault<Item>(i => TemplateManager.GetTemplate(i).InheritsFrom(Templates.MapsProvider.ID));
        if (item != null)
        {
          return item[Templates.MapsProvider.Fields.Key];
        }
      }
      return string.Empty;
    } 
    #endregion
  }
}