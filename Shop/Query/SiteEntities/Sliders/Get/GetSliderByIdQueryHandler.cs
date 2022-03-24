using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.Sliders.DTOs;

namespace Query.SiteEntities.Sliders.Get
{
    public class GetSliderByIdQueryHandler : IBaseQueryHandler<GetSliderByIdQuery, SliderDto>
    {
        private readonly ShopContext _context;

        public GetSliderByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == request.Id);
            if (slider is null) return null;

            return slider.Map();
        }
    }
}