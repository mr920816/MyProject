using Abp.Web.Mvc.Views;

namespace MyProject_Mvc5.x_ar.Web.Views
{
    public abstract class x_arWebViewPageBase : x_arWebViewPageBase<dynamic>
    {

    }

    public abstract class x_arWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected x_arWebViewPageBase()
        {
            LocalizationSourceName = x_arConsts.LocalizationSourceName;
        }
    }
}