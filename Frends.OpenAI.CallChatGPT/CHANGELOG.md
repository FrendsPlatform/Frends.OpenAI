# Changelog

## [2.0.0] - 2026-11-25
### Changed
- **[Breaking Change]** Task now targets .NET 8.
- **[Breaking Change]** Replaced the `ThrowExceptionOnErrorResponse` option with `ThrowErrorOnFailure`.
- **[Breaking Change]** The `Error` property of the result is now an object containing `Message` and `AdditionalInfo` instead of a string.
- Added the `ErrorMessageOnFailure` option for overriding the error message on failure.
- Added missing documentation examples to the result properties.

## [1.1.0] - 2025-02-17
### Changed
- Update packages:
- RestSharp                          110.2.0     -> 112.1.0
- SonarAnalyzer.CSharp               9.8.0.76515 -> 10.7.0.110445
- System.ComponentModel.Annotations  4.7.0       -> 5.0.0

## [1.0.1] - 2024-01-05
### Changed
- Moved some input parameters to options
- Moved API key from options to input

## [1.0.0] - 2023-12-28
### Changed
- Initial implementation
