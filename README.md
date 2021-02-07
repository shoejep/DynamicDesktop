# DynamicDesktop
Choose from a range of providers to create dynamic desktop backgrounds for Windows.

## Contributing
If you would like to contribute, submit a pull request with the provider you would like to add.

All you need to do is:

1. add a class that implements `IProvider` in `Models/Providers/`

2. add an entry for your provider in the enum `ProviderType`

3. add a `case` for your provider in `GetProviderByType`