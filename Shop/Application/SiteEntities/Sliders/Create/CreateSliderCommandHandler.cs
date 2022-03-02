using Domain.SiteEntities;
using Domain.SiteEntities.Repository;
using Framework.Application;
using Framework.Application.Utils;

namespace Application.SiteEntities.Sliders.Create
{
    internal class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly ISliderRepository _sliderRepository;

        public CreateSliderCommandHandler(ISliderRepository sliderRepository) => _sliderRepository = sliderRepository;

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = Uploader.ImageUploader(request.ImageName, DirectoryImages.Sliders, null!);

            var slider = new Slider(request.Title, request.Link, imageName, request.SeoImage);

            await _sliderRepository.AddEntityAsync(slider);
            await _sliderRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
