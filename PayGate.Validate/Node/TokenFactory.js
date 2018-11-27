const axios = require('axios')
const config = require('./ConfigFactory')

var _accessToken = ""
var _expireTime = 0


async function GetAccessToken () {
  if (!_accessToken === "" && _expireTime >= new Date()) {
    return _accessToken
  }

  var response = await axios.post(`${config.TokenEndpoint}`,
    'grant_type=client_credentials&scope=API',
    {
      auth: {
        username: 'validate_api',
        password: config.Secret
      }
    })

  _accessToken = response.data.access_token
  let t = new Date()
  _expireTime = t.setSeconds(t.getSeconds(), response.data.expires_in)

  return _accessToken
}

module.exports = {
  GetAccessToken
}