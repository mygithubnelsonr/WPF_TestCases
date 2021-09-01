using EF_Testcase.BLL;
using EF_Testcase.DAL;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;

namespace EF_Testcase
{
    public class FileExistValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string fullpath = "";

            var bindingGroup = value as BindingGroup;
            if (bindingGroup != null)
            {
                if (DataGetSet.Datasource == DataGetSet.DataSourceEnum.Songs)
                {
                    var song = bindingGroup.Items[0] as vSongs;
                    fullpath = Path.Combine(song.Pfad, song.FileName);
                }
                else
                {
                    var song = bindingGroup.Items[0] as vPlaylistSongs;
                    fullpath = Path.Combine(song.Pfad, song.FileName);
                }

                if (!File.Exists(fullpath))
                    return new ValidationResult(false, "File not found!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
