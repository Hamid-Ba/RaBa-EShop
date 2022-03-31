using Domain.SiteEntities.Repository;
using Framework.Application;
using Framework.Application.Utils;

namespace Application.SiteEntities.Banners.Edit
{
    internal class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;

        public EditBannerCommandHandler(IBannerRepository bannerRepository) => _bannerRepository = bannerRepository;

        public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _bannerRepository.GetAsTrackingAsyncBy(request.Id);
            if (banner is null) return OperationResult.NotFound();

            var imageName = Uploader.ImageUploader(request.ImageFile, DirectoryImages.Banners, request.ImageName);

            banner.Edit(request.Link, imageName, request.SeoImage, request.position);
            await _bannerRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}