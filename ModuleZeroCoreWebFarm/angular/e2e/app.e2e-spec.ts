import { ProjectNameTemplatePage } from './app.po';

describe('abp-project-name-template App', function() {
  let page: ProjectNameTemplatePage;

  beforeEach(() => {
    page = new ProjectNameTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
