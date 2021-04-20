<template>
  <button
    v-for="(item ,index) in aaa"
    :key="index"
    @click="func(item)"
  >{{`${index}:${item}`}}
  </button>
  <div>点击了{{select}}</div>
  <div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, reactive, toRefs } from "vue";

interface DataModel {
  aaa: string[];
  select: string;
  func: (str: number) => void;
}

export default {
  name: "App",
  components: {},
  setup() {
    const data: DataModel = reactive({
      aaa: ["a", "b"],
      select: "",
      func: (str: number) => (data.select = str.toString()),
    });

    return {
      ...toRefs(data),
    };
  },
};

// export default defineComponent({
//   name: "App",
//   components: {},
//   setup() {
//     const aaa = ref(["a", "b"]);
//     const select = ref("");
//     const func = (str: string) => (select.value = str);
//     return {
//       aaa,
//       func,
//       select,
//     };
//   },
//   data() {
//     return {
//       str: "sdfasdfasdfaf",
//     };
//   },
//   methods: {
//     func1() {
//       console.log(11111111);
//     },
//   },
// });
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
