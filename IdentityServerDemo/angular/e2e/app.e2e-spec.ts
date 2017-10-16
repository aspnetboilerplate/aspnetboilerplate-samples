import { IdentityServerDemoTemplatePage } from './app.po';

describe('abp-project-name-template App', function() {
  let page: IdentityServerDemoTemplatePage;

  beforeEach(() => {
    page = new IdentityServerDemoTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
