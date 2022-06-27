# Webapi in .Net 6

### Run the Webapi

```
git clone <repo url>
cd <repo name>
dotnet restore
dotnet publish -c Release || dotnet run -c Release
```

### Tasks

- [x] Create a webapi
- [x] Use C#
- [x] Create an endpoint to accept a post request with body content
- [x] Get data from http://api.hnb.hr/
- [x] Data must be in XML format
- [x] Save data to DB
- [x] Create a response with two fields
- [ ] Show a field with 5 decimal places

### Idea behind the project

Consumer sends a POST request with the body content of the request.

```
{
  "Datum": "2022-6-1",
  "Par": "GBP-EUR"
}
```

Server responds with an array of objects.

```
[
  {
    "Datum": "2022-6-1",
    "Odnos": "1.234567"
  },
  {
    "Datum": "2022-6-1",
    "Odnos": "1.234567"
  }
]
```