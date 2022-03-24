using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.Sliders.DTOs;

namespace Query.SiteEntities.Sliders.GetAll
{
    public class GetAllSliderQueryHandler : IBaseQueryHandler<GetAllSliderQuery, List<SliderDto>>
    {
        private readonly ShopContext _context;

        public GetAllSliderQueryHandler(ShopContext context) => _context = context;

        public async Task<List<SliderDto>> Handle(GetAllSliderQuery request, CancellationToken cancellationToken)
        {
            var sliders = await _context.Sliders.ToListAsync();

            return sliders.Select(s => s.Map()).ToList();
        }
    }
}