

const { defineConfig } = require('@vue/cli-service')

module.exports = defineConfig({
    devServer: {
        Proxy: 'http://api.sportradar.us/formula1/trial/v2/en/seasons.json?api_key=7fmnkkfvc8c455t2yng6ve73'
    }
})