using FluentValidation;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.OpenSearch;
using Sitko.Core.App;

namespace Sitko.Core.OpenSearch;

public class OpenSearchModuleOptions : BaseModuleOptions
{
    public bool LoggingEnabled => !string.IsNullOrEmpty(Url);
    public string Url { get; set; } = "";
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public string? LoggingIndexFormat { get; set; }
    public AutoRegisterTemplateVersion? LoggingTemplateVersion { get; set; }
    public int? LoggingNumberOfReplicas { get; set; }
    public string? LoggingLifeCycleName { get; set; }
    public string? LoggingRolloverAlias { get; set; }
    public EmitEventFailureHandling EmitEventFailure { get; set; } = EmitEventFailureHandling.WriteToSelfLog;
    public ILogEventSink? FailureSink { get; set; }
    public Action<LogEvent>? FailureCallback { get; set; }
    public string? LogIndexTypeName { get; set; }
}

public class OpenSearchModuleOptionsValidator : AbstractValidator<OpenSearchModuleOptions>
{
    public OpenSearchModuleOptionsValidator()
    {
        RuleFor(o => o.Url).NotEmpty().When(o => o.LoggingEnabled)
            .WithMessage("OpenSearch url can't be empty");
        RuleFor(o => o.Login).NotEmpty().When(o => o.LoggingEnabled)
            .WithMessage("OpenSearch login can't be empty");
        RuleFor(o => o.Password).NotEmpty().When(o => o.LoggingEnabled)
            .WithMessage("OpenSearch password can't be empty");
    }
}

