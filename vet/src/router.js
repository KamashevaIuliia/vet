import VueRouter from 'vue-router';
import Main from './pages/Main';

import CreateItem from './pages/CreateItem';

export default new VueRouter({
  mode: 'history',
  routes:[
    {path: "", component: Main},
    {path: "/register", component: CreateItem},
      ]
})
