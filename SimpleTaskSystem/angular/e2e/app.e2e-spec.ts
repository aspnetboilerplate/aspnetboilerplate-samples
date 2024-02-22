import { SimpleTaskSystemTemplatePage } from './app.po';

describe('SimpleTaskSystem App', function() {
  let page: SimpleTaskSystemTemplatePage;

  beforeEach(() => {
    page = new SimpleTaskSystemTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
