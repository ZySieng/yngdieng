const path = require('path');

const config = {
  projectName: 'miniapp',
  date: '2020-8-2',
  designWidth: 750,
  deviceRatio: {640: 2.34 / 2, 750: 1, 828: 1.81 / 2},
  sourceRoot: 'src',
  outputRoot: 'dist',
  plugins: [],
  defineConstants: {},
  copy: {
    patterns: [
      {
        from: 'src/sitemap.json',
        to: 'dist/sitemap.json',
      },
    ],
  },
  framework: 'react',
  alias: {
    '@': path.resolve(__dirname, '..', 'src'),
  },
  sass: {
    resource: ['src/styles/variables.scss', 'src/styles/mixins.scss'],
    projectDirectory: path.resolve(__dirname, '..'),
  },
  mini: {
    postcss: {
      pxtransform: {
        enable: true,
        config: {},
      },
      url: {
        enable: true,
        config: {
          limit: 1024, // 设定转换尺寸上限
        },
      },
      cssModules: {
        enable: true, // 默认为 false，如需使用 css modules 功能，则设为 true
        config: {
          namingPattern: 'module', // 转换模式，取值为 global/module
          generateScopedName: '[name]__[local]___[hash:base64:5]',
        },
      },
    },
  },
  h5: {
    publicPath: '/',
    staticDirectory: 'static',
    postcss: {
      autoprefixer: {enable: true, config: {}},
      cssModules: {
        enable: false, // 默认为 false，如需使用 css modules 功能，则设为 true
        config: {
          namingPattern: 'module', // 转换模式，取值为 global/module
          generateScopedName: '[name]__[local]___[hash:base64:5]',
        },
      },
    },
  },
};

module.exports = function (merge) {
  if (process.env.NODE_ENV === 'development') {
    return merge({}, config, require('./dev'));
  }
  return merge({}, config, require('./prod'));
};
