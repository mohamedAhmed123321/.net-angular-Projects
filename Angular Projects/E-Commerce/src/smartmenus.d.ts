declare module 'jquery' {
  interface JQuery<TElement = HTMLElement> {
      smartmenus(options?: any): JQuery; // Add the smartmenus method
  }
}
