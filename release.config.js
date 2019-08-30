module.exports = {
  verifyConditions: [
    () => {
      if (process.env.NUGET_TOKEN == null || process.env.NUGET_TOKEN === '$(NUGET_TOKEN)')
        throw new Error('The environment variable NUGET_TOKEN is required.')
    },
    '@semantic-release/changelog',
    '@semantic-release/git',
    '@semantic-release/github',
  ],
  prepare: [
    '@semantic-release/changelog',
    {
      path: '@semantic-release/git',
      message:
        'chore(release): ${nextRelease.version} [skip ci]\n\n${nextRelease.notes}',
    },
  ],
  publish: [
    {
      path: '@semantic-release/github',
      assets: '*.*nupkg',
    },
    {
      path: '@semantic-release/exec',
      cmd: `dotnet nuget push *.nupkg -k ${process.env.NUGET_TOKEN} -s https://api.nuget.org/v3/index.json`,
    },
  ],
}

/*
HACK: We should really be importing the semantic-release error package as below:
const SemanticReleaseError = require('@semantic-release/error');
and using that, however the import was failing when running semantic-release using npx
even when adding the @semantic-release/error package to npx.

Resorting to copying the source into this file instead
*/
class SemanticReleaseError extends Error {
  constructor(message, code) {
    super(message)
    Error.captureStackTrace(this, this.constructor)
    this.name = 'SemanticReleaseError'
    this.code = code
    this.semanticRelease = true
  }
}
