# SDL Content Delivery Test

This minimal solution is used to test different culture settings.  The reason being, when using a culture code for Turkey (tr-TR) no data is returned.

## Configure

Open `appsettings.config` and amend the following:

```
<add key="discovery-service-uri" value="https://discover-service-url/discovery.svc" />
<add key="oauth-client-id" value="cd-username" />
<add key="oauth-client-secret" value="cd-password" />
<add key="oauth-enabled" value="true" />
<add key="cultures" value="en-GB,fr-FR,tr-TR,he-IL,el-GR,xx-XX" />
<add key="publicationId" value="244" />
<add key="pageUrl" value="/index.html" />
```

Set the publication id and pageUrl for a page that has been published.

## Run

Install packages if this doesn't happen automatically, and run the app.

## Output

We are getting the following:

```
CurrentCulture is en-GB. Result: tcm:123-456789-64

CurrentCulture is fr-FR. Result: tcm:123-456789-64

CurrentCulture is tr-TR. Result: NO RESULTS

CurrentCulture is he-IL. Result: tcm:123-456789-64

CurrentCulture is el-GR. Result: tcm:123-456789-64

CurrentCulture is xx-XX. Result: tcm:123-456789-64
```

Note, no page Id returned for `tr-TR`.
