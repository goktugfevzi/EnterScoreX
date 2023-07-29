using EnterScore.Services;
using EntityLayer.Concrete;

namespace EnterScore.Areas.Admin.Method
{
    public abstract class GeneratedFileNameForCloud
    {
        private readonly ICloudStorageService _cloudStorageService;

        protected GeneratedFileNameForCloud(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        public static string GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }

    }
}
