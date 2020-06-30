<template>
  <div id="app">
    <div class="content">
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand"  href="/">Добрый врач</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              <a class="nav-link" href="/register">Запись на приём</a>
            </li>
          </ul>
        </div>
      </nav>
      <router-view></router-view>
    </div>
    <footer class="footer">{{platform.description}}</footer>
  </div>
</template>

<script>
import * as platform from "platform";

export default {
  name: 'app',
  data () {
    return {
      platform,
    }
  },
}
</script>

<style scoped>
  .content{
    padding-bottom: 16px;
    min-height: calc(100vh - 60px);
  }
  .footer{
    height: 60px;
    display: flex;
    align-items: center;
    background: rgba(0,0,0, 0.05);
    width: 100%;
    padding: 0 16px;
  }
</style>
