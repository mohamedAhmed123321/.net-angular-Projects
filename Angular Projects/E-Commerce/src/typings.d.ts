// typings.d.ts

// Import jQuery
import 'jquery';

// Declare jQuery variable
declare var $: any;

// Extend jQuery with the slick method
declare module 'jquery' {
  interface JQuery {
    slick(options?: any): JQuery;
  }
}
