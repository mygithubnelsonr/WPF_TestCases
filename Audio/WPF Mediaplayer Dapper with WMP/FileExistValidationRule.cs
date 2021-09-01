using WPFMediaplayerDapperWMP.DataAccess;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPFMediaplayerDapperWMP
{
    public class FileExistValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string fullpath = "";

            var bindingGroup = value as BindingGroup;
            if (bindingGroup != null)
            {
                if (ConnectionTools.Datasource == ConnectionTools.DataSourceEnum.Songs)
                {
                    var song = bindingGroup.Items[0] as DataAccess.vSong;
                    fullpath = Path.Combine(song.Path, song.FileName);
                }
                else
                {
                    var song = bindingGroup.Items[0] as vSong;     // vPlaylistSongs;
                    fullpath = Path.Combine(song.Path, song.FileName);
                }

                if (!File.Exists(fullpath))
                    return new ValidationResult(false, "File not found!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
