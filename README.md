# discogsharp

[![.NET](https://github.com/mlnrdns/discogsharp/actions/workflows/github-pipeline.yml/badge.svg?branch=master)](https://github.com/mlnrdns/discogsharp/actions/workflows/github-pipeline.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

.NET library to access [Discogs API](https://www.discogs.com/developers/).

## Features

* Authentication with Discogs auth flow (both personal access token and key/password is supported)
* [DataBase API](https://www.discogs.com/developers/#page:database) including image download is fully supported
* Rate limit can be added
* Full asynchronous and cancellable operation
* Pagination is supported

## Coming soon

* OAuth authentication
* Full Discogs API implementation
* Discogs monthly dump processing
* Unit tests 
## How it works

### Creating the client service

```csharp
var discogsConnection = DiscogsAuthConnection.WithPersonalAccessToken("personalAccessTokenValue");
var databaseService = discogsConnection.CreateDatabaseService();
```

### Running some queries

```csharp
var artist = databaseService.GetArtistAsync(92973);
var release = databaseService.GetReleaseAsync(3408576);
var newRating = databaseService.AddOrUpdateReleaseRatingByUserAsync(3408576, "username", 5);
```

### Searching the database

```csharp
var filter = new SearchFilter()
{
    Artist = "Ulver",
    ReleaseTitle = "Bergtatt"
};
var searchResult = databaseService.SearchAsync(filter);
```