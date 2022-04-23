import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import EvenementsTable from '../views/EvenementsView.vue'
import mainOidc from '../api/authClient.js'
import EvenementDetailsView from '../views/EvenementDetailsView.vue'
import ParticiperView from '../views/ParticiperView.vue'
const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/login',
    name: 'login',
    meta: {
      authName: mainOidc.authName
    },
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/LoginView.vue')
  },
  {
    path: '/evenements',
    name: 'evenements',
    components: {
      default: EvenementsTable,
    },
    children: [
      {
        path: '/evenements/:id',
        component: EvenementDetailsView
      },
      {
        path: '/evenements/:id/participer',
        component: ParticiperView
      },
    ]
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

mainOidc.useRouter(router);
export default router
