import js from './blog/js';
import csharp from './blog/csharp';
import blog from './blog';
import sysmenu from './sysmenu';

export default [
  {
    path: '/home',
    name: 'home',
    component: () => import('./home'),
    children: [].concat(
      js,
      csharp,
      sysmenu
    )
  }
].concat(blog);