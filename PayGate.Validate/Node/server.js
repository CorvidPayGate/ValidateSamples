// Get Dependencies
const express = require('express')
const axios = require('axios')
const config = require('./ConfigFactory')
const tokenFactory = require('./TokenFactory')

// Setup Variables
const app = express()
const port = 3000

// Setup Axios
axios.defaults.baseURL = config.BaseApiUrl

// Account Number Example
app.get('/api/Example/AccountNumber', async (req, res) => {
  let accessToken = await tokenFactory.GetAccessToken()
  let response = await axios.post('/api/AccountNumber',
    { SortCode: '010101', KeyCode: config.Keycode },
    { headers: { Authorization: `Bearer ${accessToken}` } })

  res.send(response.data)
})

// Credit Card Example
app.get('/api/Example/CreditCard', async (req, res) => {
  let accessToken = await tokenFactory.GetAccessToken()
  let response = await axios.post('/api/CreditCard',
    { CreditCardNumber: '4111111111111111', KeyCode: config.Keycode },
    { headers: { Authorization: `Bearer ${accessToken}` } })

  res.send(response.data)
})

// Iban Example
app.get('/api/Example/Iban', async (req, res) => {
  let accessToken = await tokenFactory.GetAccessToken()
  let response = await axios.post('/api/Iban',
    { Iban: 'GB32ESSE40486562136016', KeyCode: config.Keycode },
    { headers: { Authorization: `Bearer ${accessToken}` } })

  res.send(response.data)
})

// Setup server to listen on the post specified
app.listen(port, () => console.log(`PayGate.Validate.Example is listening on port ${port}`))
