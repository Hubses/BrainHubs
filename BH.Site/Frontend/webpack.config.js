var webpack = require('webpack');

var HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: {
        'polyfills': './src/polyfills.ts',
        'vendor': './src/vendor.ts',
        'app': './src/main.ts'
    },

    output: {
        path: 'build',
        filename: '[name].js',
        chunkFilename: '[id].chunk.js'
    },

    devtool: 'source-map',
    resolve: {
        extensions: ['', '.js', '.ts']
    },

    module: {
        loaders: [
            { test: /\.ts$/, loaders: ['awesome-typescript-loader'] },
            { test: /\.html$/, loader: 'raw!html-minify' },
            { test: /\.css$/, loader: 'style-loader!css-loader' },
            {
                test: /\.(png|woff|woff2|eot|ttf|svg|jpg|ico)(\?[a-z0-9=\.]+)?$/,
                loader: 'url-loader'
            }
        ]
    },

    plugins: [
        new webpack.optimize.CommonsChunkPlugin({
            name: ['app', 'vendor', 'polyfills']
        }),
        new HtmlWebpackPlugin({
            template: 'src/index.html'
        }),
        new webpack.optimize.UglifyJsPlugin({
            compress: { warnings: false }
        })
    ],
    'html-minify-loader': {
        empty: true,        // KEEP empty attributes
        cdata: true,        // KEEP CDATA from scripts
        comments: true,     // KEEP comments
        dom: {                            // options of !(htmlparser2)[https://github.com/fb55/htmlparser2]
            lowerCaseAttributeNames: false,      // do not call .toLowerCase for each attribute name (Angular2 use camelCase attributes)
        }
    }
};