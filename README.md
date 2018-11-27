# Introduction
This repository is meant to show you how to use Paygate's API's, by requesting a token and then using that to call the endpoint of your choice. There are runnable examples in each folder relating to each project, but the main bulk of it is here.

In the examples here I'm going to be using JavaScript with Axios

# Getting  a Token
We use oAuth2 to secure our endpoints, you should be given a `secret key`/`api key`, this must remain secret from anyone otherwise they will be able to request tokens and act as if they were you, think of it as your _password_.

## How to request a token

Once you have your `secret key` you can request a token from our token endpoint `https://portal.paygate.cloud/IdentityServer/identity/connect/token` to do this you need to make a post request

```js
axios.post(
  'https://portal.paygate.cloud/IdentityServer/identity/connect/token',
  'grant_type=client_credentials&scope=API',
  {
    auth: {
      username: '**api_name**',
      password: '**api_key**'
    }
  }
);
```

This (if it's right) will return an object like this

```JSON
{
  "access_token": "eyJ0eXA...",
  "expires_in": 3600,
  "token_type": "Bearer"
}
```

You can then use this in the auth header of your request

```js
let tokenResponse = {'...response from above...'}

axios.get('http://somecovidapi/api/getStuff',{
  headers: { Authorization: `Bearer ${tokenResponse.access_token}` }
})
```

### Extras
You **do not** need to request a new token for each request, in the token response you'll notice there's a `expires_in` property this is the amount of seconds from requesting the token on when it will expire, in the example above, that would be an hour, so you can use this token for an hour before it expires. 

You will have to manage this yourself, although there are a few libraries out there that can help with this.
[Identity model is a good choice](https://github.com/IdentityModel)

# Project Examples
- [Validate C# .Net Core](https://github.com/CorvidPayGate/ValidateSamples/tree/master/PayGate.Validate/C%23)
- [Validate NodeJs](https://github.com/CorvidPayGate/ValidateSamples/tree/master/PayGate.Validate/Node)