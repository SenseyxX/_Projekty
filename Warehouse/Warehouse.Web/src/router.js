import Vue from "vue";
import Router from "vue-router";
import loginRoutes from "./pages/login/router";

Vue.use(Router);

const routes = [loginRoutes];

const router = new Router({
  routes: routes,
});

router.beforeEach((to, from, next) => {
  const isValidRoute = routes.some((route) => route.path === to.path);
  if (!isValidRoute) {
    next("login");
  } else {
    next();
  }
});

export default router;
