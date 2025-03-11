using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;
using Dados;

namespace Agenda.Pages.Shared
{
    public abstract class PageBaseCadFormModel<TVmEntity> : PageModel where TVmEntity : BaseVm, new()
    {
        protected IBaseService<TVmEntity> DataService { get; }

        protected PageBaseCadFormModel(IBaseService<TVmEntity> servicesBase) : base()
        {
            DataService = servicesBase;
        }

        [BindProperty(SupportsGet = true)]
        public string? Id { get; set; }

        public bool Edicao { get; set; }

        [BindProperty]
        public TVmEntity EntityVm { get; set; }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            Edicao = !string.IsNullOrEmpty(Id);
            if (string.IsNullOrEmpty(Id))
            {
                EntityVm = new TVmEntity();
                EntityVm.Id = Guid.NewGuid().ToString("N");
                return Page();
            }
            else
            {
                await OnEditarRegistroAsync(await DataService.GetByIdAsync(Id));
                return Page();
            }
        }

        public virtual Task OnEditarRegistroAsync(TVmEntity modelVm)
        {
            EntityVm = modelVm;
            return Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            EntityVm.DataCadastro = DateTime.Now;
            EntityVm.Excluido = false;
            if (!ModelState.IsValid)
            {
                return Page();
                
            }

            if (string.IsNullOrEmpty(Id))
            {
                await DataService.AddAsync(EntityVm);
            }
            else
            {
                await DataService.UpdateAsync(EntityVm);
            }

            var previousPage = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrEmpty(previousPage))
            {
                var uri = new Uri(previousPage);

                var cleanUri = uri.GetLeftPart(UriPartial.Path);

                if (cleanUri.EndsWith("Cad"))
                {
                    cleanUri = cleanUri.Substring(0, cleanUri.Length - 3);
                }

                return Redirect(cleanUri);
            }
            return RedirectToPage();

        }
    }
}
