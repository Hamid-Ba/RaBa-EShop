using Domain.SiteEntities.Repository;
using Framework.Application;
using Framework.Application.Utils;

namespace Application.SiteEntities.Sliders.Edit
{
    internal class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        private readonly ISliderRepository _sliderRepository;

        public EditSliderCommandHandler(ISliderRepository sliderRepository) => _sliderRepository = sliderRepository;

        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _sliderRepository.GetEntityAsyncBy(request.Id);
            if (slider is null) return OperationResult.NotFound();

            var imageName = Uploader.ImageUploader(request.ImageFile, DirectoryImages.Sliders, request.ImageName);

            slider.Edit(request.Title, request.Link, imageName, request.SeoImage);
            await _sliderRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
