# Basic Concepts

The following outlines good to know, basic concepts for ZeroRedact.

## What is redaction?

Redaction is obscuring a piece of data. We often use it to protect private or confidential information such as [Personally Identifiable Information](https://en.wikipedia.org/wiki/Personal_data) (PII). This is what you see in documents with blacked out lines. 

Redaction is the goal of ZeroRedact.

This similar, but different to *masking*, [via AWS](https://aws.amazon.com/what-is/data-masking/):
>Data masking creates fake versions of an organization's data by changing confidential information. Various techniques are used to create realistic and structurally similar changes. Once data is masked, you can’t reverse engineer or track back to the original data values without access to the original dataset.

A simple example for masking would be taking an address, and replacing each part (street number, suburb, etc) with a different but valid piece of data. The address is still an address structure and valid looking, but now isn't the PII it was before.
For more in depth, feel free to read: [Data Masking vs. Data Redaction: Key Differences and Uses by Graham Thompson at Privacy Dynamics](https://web.archive.org/web/20241203000821/https://www.privacydynamics.io/post/data-masking-vs-data-redaction-key-differences-and-uses/) (Wayback Machine).

## Configuration 

ZeroRedact uses a cascading configuration model. Options "closer" to the redaction time will overwrite prior options. For example, the redaction character can be set in three places:

1. On `RedactorOptions` at `Redactor` construction time
1. On a specific redaction type option, such as `StringRedactorOptions` which can be passed to the `Redactor` object at construction time
1. In the redaction call, such as passing `StringRedactorOptions` to `RedactString()`

The third will take precedence over all previous settings. This allows for good defaults and fine grained control when needed.

## Exceptions

ZeroRedact will not throw exceptions during _redaction_. If an exception occurs, a default fixed length redaction is provided. This is from a safety first perspective where the highest level of redaction is used when the situation is unknown. This is preferrable over leaking data or interrupting code flow. See [General Design](design/general-design.md) for more.
