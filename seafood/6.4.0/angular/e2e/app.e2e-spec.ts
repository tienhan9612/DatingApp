import { seafoodTemplatePage } from './app.po';

describe('seafood App', function() {
  let page: seafoodTemplatePage;

  beforeEach(() => {
    page = new seafoodTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
