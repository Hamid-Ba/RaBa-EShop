using Domain.SiteEntities;
using Domain.SiteEntities.Repository;
using Framework.Application;
using Framework.Application.Utils;

namespace Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;

        public CreateBannerCommandHandler(IBannerRepository bannerRepository) => _bannerRepository = bannerRepository;

        public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var imageName = Uploader.ImageUploader(request.ImageName, DirectoryImages.Banners, null!);

            var banner = new Banner(request.Link, imageName, request.SeoImage, request.Position);

            await _bannerRepository.AddEntityAsync(banner);
            await _bannerRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
