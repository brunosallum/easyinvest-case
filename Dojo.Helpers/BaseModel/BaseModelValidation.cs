using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dojo.Helpers.BaseModel
{
    public abstract class BaseModelValidation
    {
        [JsonIgnore]
        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
