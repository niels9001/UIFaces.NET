# UIFaces.NET
A .NET Standard Library for using the [UI Faces API](https://uifaces.co/).

## Usage
The main class is [`UIFacesService`](https://github.com/niels9001/UIFaces.NET/blob/master/UIFaces.NET/Services/UIFacesService.cs). When using it you will need provide your API key [here](https://uifaces.co/api-docs).

Once you have an instance of the class, use `GetFaces` to use the API which will return a List of [`Person`](https://github.com/niels9001/UIFaces.NET/blob/master/UIFaces.NET/Models/Person.cs)

## Sample app
The sample app is a UWP app that contains of a filter panel (for the various parameters) and a results GridView.
Make sure to register for a proper API key [here](https://uifaces.co/api-docs).

![Screenshot](https://github.com/niels9001/UIFaces.NET/blob/master/SampleAppScreenshot.PNG)
