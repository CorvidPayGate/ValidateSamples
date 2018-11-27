const _ = require('lodash')
const optionalRequire = require("optional-require")(require);

// Setup Config
const baseConfig = require('./appsettings.json')
const localConfig = optionalRequire('./appsettings.local.json') || {}
const config = _.merge(baseConfig, localConfig)

module.exports = config