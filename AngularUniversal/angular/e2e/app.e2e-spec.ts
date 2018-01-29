import { HeroShopTemplatePage } from './app.po';

describe('HeroShop App', function() {
  let page: HeroShopTemplatePage;

  beforeEach(() => {
    page = new HeroShopTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
