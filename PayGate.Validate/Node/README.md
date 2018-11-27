# PayGate.Validate Node
Example Api for using the PayGate Validate Api

## Features
- Getting token for authentication
- Sending request to API with token
- Sample Account Number, Credit Card and Iban requests

## Installing 

```bash
$ git clone https://github.com/CorvidPayGate/ValidateSamples

$ cd ValidateSamples\PayGate.Validate\Node

$ npm i
```

Replace `Secret` and `Keycode` in `appsettings.json`

```bash
$ npm run start
```

## Example 

```bash
$ curl 'http://localhost:3000/api/Example/AccountNumber'
```


## Resources
* [Swagger API Documentation](https://validate.paygate.cloud/validateonlineapi/swagger/ui/index)