namespace Sitecore.Support.XA.Feature.Search.Pipelines.IoC
{
  using Microsoft.Extensions.DependencyInjection;
  using Sitecore.XA.Feature.Search.Repositories;
  using Sitecore.XA.Foundation.IOC.Pipelines.IOC;
  using Sitecore.XA.Foundation.Search.Services;

  public class RegisterSearchsServices : Sitecore.XA.Feature.Search.Pipelines.IoC.RegisterSearchsServices
  {
    public override void Process(IocArgs args)
    {
      args.ServiceCollection.AddTransient<ISearchBoxRepository, SearchBoxRepository>();
      args.ServiceCollection.AddTransient<ISearchResultsRepository, SearchResultsRepository>();
      args.ServiceCollection.AddTransient<IChecklistFilterRepository, ChecklistFilterRepository>();
      args.ServiceCollection.AddTransient<IDateFilterRepository, DateFilterRepository>();
      args.ServiceCollection.AddTransient<IDropdownFilterRepository, DropdownFilterRepository>();
      args.ServiceCollection.AddTransient<IFacetSliderRepository, FacetSliderRepository>();
      args.ServiceCollection.AddTransient<ILoadMoreRepository, LoadMoreRepository>();
      args.ServiceCollection.AddTransient<IManagedRangeSelectorRepository, ManagedRangeSelectorRepository>();
      args.ServiceCollection.AddTransient<IPageSelectoreRepository, PageSelectoreRepository>();
      args.ServiceCollection.AddTransient<IPageSizeRepository, PageSizeRepository>();
      args.ServiceCollection.AddTransient<IResultsCountRepository, ResultsCountRepository>();
      args.ServiceCollection.AddTransient<IResultsVariantSelectorRepository, ResultsVariantSelectorRepository>();
      args.ServiceCollection.AddTransient<ISortResultsRepository, SortResultsRepository>();
      args.ServiceCollection.AddTransient<IRadiusFilterRepository, RadiusFilterRepository>();
      args.ServiceCollection.AddTransient<IScopeService, ScopeService>();
      #region Changed code
      args.ServiceCollection.AddTransient<ILocationFilterRepository, Sitecore.Support.XA.Feature.Search.Repositories.LocationFilterRepository>(); 
      #endregion
      args.ServiceCollection.AddTransient<IRangeSliderRepository, RangeSliderRepository>();
    }
  }
}