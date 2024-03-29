# discogsharp
[![Github Actions](https://github.com/mlnrdns/discogsharp/actions/workflows/build.yml/badge.svg?branch=master)](https://github.com/mlnrdns/discogsharp/actions/workflows/build.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

.NET library to access [Discogs API](https://www.discogs.com/developers/).

## Features

* Authentication with Discogs auth flow (both personal access token and key/password is supported)
* Full support for:
    * [Database API](https://www.discogs.com/developers/#page:database) including image download
    * [Collection API](https://www.discogs.com/developers#page:user-collection)
    * [User WantList API](https://www.discogs.com/developers#page:user-wantlist)
    * [User Lists API](https://www.discogs.com/developers#page:user-lists)
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
var artist = await databaseService.GetArtistAsync(92973);
var release = await databaseService.GetReleaseAsync(3408576);
var newRating = await databaseService.AddOrUpdateReleaseRatingByUserAsync(3408576, "username", 5);
```

### Searching the database

```csharp
var filter = new SearchFilter()
{
    Artist = "Ulver",
    ReleaseTitle = "Bergtatt"
};
var searchResult = await databaseService.SearchAsync(filter);
```
